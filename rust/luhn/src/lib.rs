fn valid_format(code: &str) -> bool {
    code.chars()
        .any(|char| !(char.is_ascii_whitespace() || char.is_ascii_digit()))
        || code.trim() == "0"
}

/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    if valid_format(code) {
        return false;
    }

    code.chars()
        .rev()
        .filter(|char| char.is_ascii_digit())
        .enumerate()
        .map(|(index, char)| {
            let digit = char.to_digit(10).unwrap();
            let mut total = digit;

            if index % 2 == 1 {
                total *= 2;

                if total > 9 {
                    total -= 9;
                }
            }

            total
        })
        .sum::<u32>()
        % 10
        == 0
}
