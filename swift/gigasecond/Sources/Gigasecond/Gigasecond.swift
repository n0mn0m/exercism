//Solution goes in Sources
import Foundation

private var cachedFormatters = [String : DateFormatter]()

extension DateFormatter {
    static func cached(withFormat format: String) -> DateFormatter {
        if let cachedFormatter = cachedFormatters[format] { return cachedFormatter }
        let formatter = DateFormatter()
        formatter.dateFormat = format
        formatter.locale = Locale(identifier: "en_US_POSIX")
        formatter.timeZone = TimeZone(abbreviation: "UTC")
        cachedFormatters[format] = formatter
        return formatter
    }
}

struct Gigasecond {
    var description: Optional<String> = nil

    init?(from: String) {
        let giga: TimeInterval = 1_000_000_000
        let formatter = DateFormatter.cached(withFormat: "yyyy-MM-dd'T'HH:mm:ss")
        guard let d = formatter.date(from: from) else {
            return nil
        }
        let n = d.addingTimeInterval(giga)
        description = formatter.string(for: n)
    }
}
