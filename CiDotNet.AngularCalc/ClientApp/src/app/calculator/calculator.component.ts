import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';
import { CalculationData } from './models/calculation-data';
import { CalculationService } from './calculation.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  calcForm: FormGroup
  durations = [6,12,18,24,30,36];
  payment = '';
  submitted = false;

  constructor(private formBuilder: FormBuilder, private calculationService: CalculationService) { 
    this.calcForm = this.createFormGroup();
  }

  ngOnInit() {
  }

  onSubmit() {
    this.submitted = true;
    if (this.calcForm.invalid) {
        return;
    }

    const result: CalculationData = Object.assign({}, this.calcForm.value);

    this.calculationService.postCalculationData(result).then(result => {
      this.payment = result.result;     
      },
       error => {
        console.log(error);
    });
  }

  get f() { return this.calcForm.controls; }

  wiborClick() {
    this.calculationService.getWibor().then(result => {
      this.f.interestRate.setValue(result.result);
      },
       error => {
        console.log(error);
    });
  }

  createFormGroup() {
    return this.formBuilder.group({
      price: ['30000', [Validators.required,Validators.pattern("^[0-9]+(\.[0-9]+)?$")] ],
      duration: '12',
      residualValue: ['5000', [Validators.required,Validators.pattern("^[0-9]+(\.[0-9]+)?$")] ],
      interestRate: ['7.5', [Validators.required,Validators.pattern("^[0-9]+(\.[0-9]+)?$")] ],
      calculationMode: '1'
    });
  }

}
