use std::collections::HashSet;

fn standardise(word: &str) -> Vec<char> {
    // conform words to a standard for easier comparison focused
    // on contents not original order.
    let mut c: Vec<_> = word.to_lowercase().chars().collect();
    c.sort();
    c
}

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &'a [&str]) -> HashSet<&'a str> {
    let lowered = word.to_lowercase();
    let std = standardise(word);

    possible_anagrams
        .iter()
        .filter(|&c| c.to_lowercase() != lowered && standardise(c) == std)
        .copied()
        .collect()
}

