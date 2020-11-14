//Solution goes in Sources
struct Year {
    let calendarYear: Int
    let isLeapYear: Bool

    init(calendarYear: Int) {
        self.calendarYear = calendarYear
        isLeapYear = (calendarYear % 4 == 0) && (calendarYear % 100 != 0 || calendarYear % 400 == 0)
    }
}
