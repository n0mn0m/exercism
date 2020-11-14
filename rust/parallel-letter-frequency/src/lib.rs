use std::collections::HashMap;
use std::thread;

fn sanitize(input: Vec<char>) -> Vec<char> {
    input
        .iter()
        .map(|i| i.to_ascii_lowercase())
        .filter(|c| c.is_alphabetic())
        .collect()
}

fn pcount(partitions: Vec<String>, workers: usize) -> HashMap<char, usize> {
    let mut threads = Vec::with_capacity(workers);
    let mut freq: HashMap<char, usize> = HashMap::new();

    for i in 0..partitions.len() {
        let part = partitions[i].clone();
        threads.push(thread::spawn(move || {
            let mut piece: HashMap<char, usize> = HashMap::new();
            part.chars().for_each(|c| {
                *piece.entry(c).or_insert(0) += 1;
            });
            piece
        }))
    }

    for t in threads {
        let part = t.join().unwrap();
        for (key, val) in part.iter() {
            *freq.entry(*key).or_insert(0) += val;
        }
    }

    freq
}

pub fn frequency(input: &[&str], worker_count: usize) -> HashMap<char, usize> {
    let joined: Vec<_> = input.join("").chars().collect();

    if joined.len() == 0 || worker_count == 0 {
        return HashMap::new();
    }

    let letters = sanitize(joined);
    let partition_size = (letters.len() / worker_count).max(1);

    let partitions: Vec<_> = letters
        .chunks(partition_size)
        .map(|it| it.iter().collect::<String>())
        .collect();

    pcount(partitions, worker_count)
}
