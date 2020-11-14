/// Given a list of poker hands, return a list of those hands which win.
///
/// Note the type signature: this function should return _the same_ reference to
/// the winning hand(s) as were passed in, not reconstructed strings which happen to be equal.
use std::cmp::{Ord, Ordering};
use std::collections::HashMap;

const CARD_VALUE: &[&str] = &[
    "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A",
];

#[derive(PartialEq, PartialOrd, Eq, Debug)]
enum PokerRank {
    StraightFlush(u8),
    FourOfAKind(u8, u8),
    FullHouse(u8, u8),
    Flush(u8, u8, u8, u8, u8),
    Straight(u8),
    ThreeOfAKind(u8, u8, u8),
    TwoPair(u8, u8, u8),
    OnePair(u8, u8, u8, u8),
    HighCard(u8, u8, u8, u8, u8),
}

impl PokerRank {
    fn value(&self) -> Vec<u8> {
        match self {
            PokerRank::StraightFlush(one) => vec![8, *one],
            PokerRank::FourOfAKind(one, two) => vec![7, *one, *two],
            PokerRank::FullHouse(one, two) => vec![6, *one, *two],
            PokerRank::Flush(one, two, three, four, five) => {
                vec![5, *one, *two, *three, *four, *five]
            }
            PokerRank::Straight(one) => vec![4, *one],
            PokerRank::ThreeOfAKind(one, two, three) => vec![3, *one, *two, *three],
            PokerRank::TwoPair(one, two, three) => vec![2, *one, *two, *three],
            PokerRank::OnePair(one, two, three, four) => vec![1, *one, *two, *three, *four],
            PokerRank::HighCard(one, two, three, four, five) => {
                vec![0, *one, *two, *three, *four, *five]
            }
        }
    }
}

impl Ord for PokerRank {
    fn cmp(&self, other: &Self) -> Ordering {
        self.value()
            .iter()
            .zip(other.value())
            .map(|(a, b)| a.cmp(&b))
            .find(|result| *result != Ordering::Equal)
            .unwrap_or(Ordering::Equal)
    }
}

#[derive(Debug, PartialEq)]
struct Card(u8, char);

fn to_cards(hand: &str) -> Vec<Card> {
    hand.split_whitespace()
        .map(|card_str| {
            let (value, suit) = card_str.split_at(card_str.len() - 1);

            Card(
                CARD_VALUE
                    .iter()
                    .position(|card_value| *card_value == value)
                    .unwrap() as u8
                    + 1,
                suit.chars().next().unwrap(),
            )
        })
        .collect::<Vec<_>>()
}

fn generate_value_pairs(cards: &[Card]) -> Vec<(u8, i32)> {
    let mut value_pairs: Vec<(u8, i32)> = cards
        .iter()
        .fold(HashMap::new(), |mut acc, item| {
            *acc.entry(item.0).or_insert(0) += 1;
            acc
        })
        .into_iter()
        .collect::<Vec<_>>();

    value_pairs.sort_by(|a, b| {
        if a.1 == b.1 {
            b.0.cmp(&a.0)
        } else {
            b.1.cmp(&a.1)
        }
    });

    value_pairs
}

fn is_flush(cards: &[Card]) -> bool {
    let suit = cards.first().unwrap().1;
    cards.iter().all(|card| card.1 == suit)
}

fn is_straight(cards: &[Card]) -> bool {
    let last_index = CARD_VALUE.len() as u8;

    cards.windows(2).all(|items| {
        let first_index = items.first().unwrap().0;
        let second_index = items.last().unwrap().0;

        (first_index - second_index) == 1 || (first_index == last_index && second_index == 4)
    })
}

fn score_hand(hand: &str) -> PokerRank {
    let mut cards = to_cards(hand);
    cards.sort_by(|a, b| b.0.cmp(&a.0));

    let is_flush = is_flush(&cards);
    let is_straight = is_straight(&cards);

    // demote ace low
    if is_straight && cards[0].0 as usize == CARD_VALUE.len() && cards.last().unwrap().0 == 1 {
        cards[0].0 = 0;
    }

    match generate_value_pairs(&cards) {
        x if x[0].1 == 4 => PokerRank::FourOfAKind(x[0].0, x[1].0),
        x if x[0].1 == 3 && x[1].1 == 2 => PokerRank::FullHouse(x[0].0, x[1].0),
        x if x[0].1 == 3 => PokerRank::ThreeOfAKind(x[0].0, x[1].0, x[2].0),
        x if x[0].1 == 2 && x[1].1 == 2 => PokerRank::TwoPair(x[0].0, x[1].0, x[2].0),
        x if x[0].1 == 2 => PokerRank::OnePair(x[0].0, x[1].0, x[2].0, x[3].0),
        // if not a value pair rank move into full hand.
        _x if is_straight && is_flush => PokerRank::StraightFlush(cards[0].0),
        _x if is_flush => {
            PokerRank::Flush(cards[0].0, cards[1].0, cards[2].0, cards[3].0, cards[4].0)
        }
        _x if is_straight => PokerRank::Straight(cards[0].0),
        _ => PokerRank::HighCard(cards[0].0, cards[1].0, cards[2].0, cards[3].0, cards[4].0),
    }
}

pub fn winning_hands<'a>(hands: &'a [&'a str]) -> Option<Vec<&'a str>> {
    let hand_values = hands.iter().fold(HashMap::new(), |mut acc, hand| {
        acc.insert(*hand, score_hand(*hand));
        acc
    });

    let max_hand = hand_values.values().max()?;

    Some(
        hand_values
            .iter()
            .filter(|(_, hand_value)| **hand_value == *max_hand)
            .map(|(hand, _)| *hand)
            .collect::<Vec<_>>(),
    )
}
