import { TestBed } from '@angular/core/testing';

import { CalculationService } from './calculation.service';

describe('CalculatorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CalculationService = TestBed.get(CalculationService);
    expect(service).toBeTruthy();
  });
});
