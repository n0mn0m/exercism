fn sqrt(n: u32) -> u32 {
    (n as f64).sqrt() as u32
}

fn is_prime(n: u32) -> bool {
    match n < 2 {
        true => false,
        false => (2..=sqrt(n)).all(|m| n % m != 0),
    }
}

pub fn nth(n: u32) -> u32 {
    (2..).filter(|x| is_prime(*x)).nth(n as usize).unwrap()
}
