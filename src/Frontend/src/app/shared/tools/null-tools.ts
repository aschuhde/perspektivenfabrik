export function stringEmptyPropagate(value: string | null | undefined, defaultIfNullOrEmpty: string): string {
  if(!value){
    return defaultIfNullOrEmpty;
  }
  return value;
}