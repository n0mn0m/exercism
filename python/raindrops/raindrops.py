def convert(n):
    """Convert a number to a string according to raindrop sound values."""
    drops = ((3, 'Pling'), (5, 'Plang'), (7, 'Plong'))

    spoke = [speak for value, speak in drops if n % value == 0]
    return "".join(spoke) if spoke else str(n)
