export enum BandColors {
  black,
    brown,
    red,
    orange,
    yellow,
    green,
    blue,
    violet,
    grey,
    white
}

export class ResistorColor {
  constructor(private readonly colors: BandColors[]) {
    if(colors.length < 2){
      throw new Error("At least two colors need to be present")
    }
  }

  public value(): number {
      return  this.colors[0] * 10 + this.colors[1];
  }
}
