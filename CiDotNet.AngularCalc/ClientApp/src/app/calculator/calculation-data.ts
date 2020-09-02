export enum Mode {
    BeginMode = 1, EndMode = 0
}

export class CalculationData {
  price: number;
  duration: number;
  residualValue: number;
  interestRate: number;
  calculationMode: Mode;
}
