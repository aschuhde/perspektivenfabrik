export function parseMoneyWithFallback(value: any, fallback: number | null): number | null{
    return parseFloatWithFallback(value.replace("€", "").trim() ?? "", fallback);
}

export function parseFloatWithFallback(value: any, fallback: number | null): number | null{
    const f = parseFloat(value?.replace(".", "").replace(",", "."));
    if(isNaN(f)){
        return fallback;
    }
    return f;
}

export function getShortYear(year: number): number{
    return year - 2000;
}

export function getEffortHoursWithHourUnit(effortHours: string): string{
    if(effortHours.trim().endsWith("h")){
        return effortHours;
    }
    return `${effortHours}h`;
}

export function parseEffortHours(value: string | null | undefined): {effortHours: string | null, effortHoursType: "perWeek" | "total"}{
    const parts = value?.split(" ") ?? [];
    if(parts.length === 0){
        return {
            effortHours: null,
            effortHoursType: "perWeek"
        }
    }
    if(parts.length === 1){
        return {
            effortHours: getEffortHoursWithHourUnit(parts[0]),
            effortHoursType: "perWeek"
        }
    }
    const effortHoursType = parts[parts.length - 1]?.toLowerCase()?.trim() !== "perweek" ? "perWeek" : "total";
    return {
        effortHours: getEffortHoursWithHourUnit(parts[0]),
        effortHoursType: effortHoursType
    }
}