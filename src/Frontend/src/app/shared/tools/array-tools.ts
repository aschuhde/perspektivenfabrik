export function shuffle<T>(array: T[]): T[] {
    const shuffled = [...array];
    for (let i = shuffled.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [shuffled[i], shuffled[j]] = [shuffled[j], shuffled[i]];
    }
    return shuffled;
}

export function distinctBy<T, K>(array: T[], selector: (item: T) => K): T[] {
    const seen = new Map<K, T>();
    array.forEach(item => {
        const key = selector(item);
        if (!seen.has(key)) {
            seen.set(key, item);
        }
    });
    return Array.from(seen.values());
}

