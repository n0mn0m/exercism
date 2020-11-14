#[derive(Debug, PartialEq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist<T: PartialEq>(_first_list: &[T], _second_list: &[T]) -> Comparison {
    match (_first_list.len(), _second_list.len()) {
        _ if _first_list == _second_list => Comparison::Equal,
        (a, b) if a < b && contains(_first_list, _second_list) => Comparison::Sublist,
        (a, b) if a > b && contains(_second_list, _first_list) => Comparison::Superlist,
        _ => Comparison::Unequal,
    }
}

pub fn contains<T: PartialEq>(x: &[T], y: &[T]) -> bool {
    x.is_empty() || y.windows(x.len()).any(|_window| _window == x)
}
