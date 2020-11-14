use std::collections::HashSet;

const MINE: char = '*';
const EMPTY: char = ' ';

/// Transforming the array of strings to a set of coordiantes where mines exist.
fn identify_mine_coordinates(minefield: &[&str]) -> HashSet<(i32, i32)> {
    let mut cells_with_mines = HashSet::new();

    minefield.iter().enumerate().for_each(|(y, row)| {
        row.chars().enumerate().for_each(|(x, cell)| {
            if cell == MINE {
                cells_with_mines.insert((x as i32, y as i32));
            }
        })
    });

    cells_with_mines
}

/// Based on our current board coordinate (x,y) count how many neighbors are mines
/// by comparing neighbor coordinates to the mine coordinate set.
fn identify_neighbors_with_mines(
    x: usize,
    y: usize,
    mine_coordinates: &HashSet<(i32, i32)>,
) -> usize {
    let x_pos = x as i32;
    let left = x_pos - 1;
    let right = x_pos + 1;

    let y_pos = y as i32;
    let top = y_pos - 1;
    let bottom = y_pos + 1;

    vec![
        (left, top),
        (left, y_pos),
        (left, bottom),
        (x_pos, top),
        (x_pos, bottom),
        (right, top),
        (right, y_pos),
        (right, bottom),
    ]
    .iter()
    .filter(|coordinates| mine_coordinates.contains(coordinates))
    .count()
}

pub fn annotate(minefield: &[&str]) -> Vec<String> {
    let cells_with_mines = identify_mine_coordinates(minefield);

    minefield
        .iter()
        .enumerate()
        .map(|(y, row)| {
            row.chars()
                .enumerate()
                .map(|(x, cell)| {
                    if cell == MINE {
                        return MINE.to_string();
                    }

                    let neighbor_mines = identify_neighbors_with_mines(x, y, &cells_with_mines);

                    match neighbor_mines {
                        0 => EMPTY.to_string(),
                        _ => neighbor_mines.to_string(),
                    }
                })
                .collect()
        })
        .collect()
}
