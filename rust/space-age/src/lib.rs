// The code below is a stub. Just enough to satisfy the compiler.
// In order to pass the tests you can add-to or change any of this code.

#[derive(Debug)]
pub struct Duration {
    seconds: u64,
}

impl From<u64> for Duration {
    fn from(seconds: u64) -> Self {
        Duration { seconds }
    }
}

pub trait Planet {
    fn years_during(d: &Duration) -> f64;
}

macro_rules! planet_impl {
    ($type:ident, $earth_years:expr) => {
        pub struct $type;

        impl Planet for $type {
            fn years_during(d: &Duration) -> f64 {
                d.seconds as f64 / (31_557_600 as f64 * $earth_years)
            }
        }
    };
}

planet_impl!(Mercury, 0.240_846_7);
planet_impl!(Venus, 0.615_197_26);
planet_impl!(Earth, 1.0);
planet_impl!(Mars, 1.880_815_8);
planet_impl!(Jupiter, 11.862_615);
planet_impl!(Saturn, 29.447_498);
planet_impl!(Uranus, 84.016_846);
planet_impl!(Neptune, 164.79132);
