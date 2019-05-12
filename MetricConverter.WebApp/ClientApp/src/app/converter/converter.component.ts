import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from "@angular/forms";
import { debug } from 'util';

@Component({
  selector: 'app-converter-component',
  templateUrl: './converter.component.html'
})

export class ConverterComponent {
  constructor(httpclient: HttpClient, public fb: FormBuilder) {
    this.http = httpclient;
    //get the units the user can select in the first availalbe list box
    this.http.get('https://localhost:44374/api/Convert/FromUnits').subscribe(result => {
      this.fromUnits = result;
    }, error => console.error(error));
  }

  convertForm = this.fb.group({
    fromUnit: [''],
    toUnit: [''],
    fromValue: 0.0
  })

  public showResults: boolean = false;
  public toUnitVisibility: boolean = false;
  public fromValue: number = 0.0;
  public http: HttpClient;
  public fromUnit: "";
  public toUnit: "";
  public rate: number = 0.0;
  public result: number = 0.0;
  public fromUnits: any = ['Centimeter', 'Inch', 'Meter', 'Yard', 'Celcius', 'Fahreinheit'];
  public toUnits: any = [''];

  public changeFromUnit() {
    this.showResults = false;
    //alert("Changed From Unit: " + JSON.stringify(this.convertForm.value.fromUnit));
    this.fromUnit = this.convertForm.value.fromUnit;
    //now that the user has selected the from unit we can determine which units are setup to be converted to
    this.http.get('https://localhost:44374/api/Convert/ToUnits/' + this.fromUnit).subscribe(result => {
      this.toUnits = result;
      this.toUnitVisibility = true;
    }, error => console.error(error));

  }

  public changeToUnit() {
    this.toUnit = this.convertForm.value.toUnit;
    this.showResults = false;
  }

  public changeFromValue() {
    this.fromValue = this.convertForm.value.fromValue;
    //alert("Changed From Value: " + JSON.stringify(this.convertForm.value.fromValue));
    this.showResults = false;
  }

  onSubmit() {
    //this.rate = 2.4;
    //alert("Submitted: " + JSON.stringify(this.convertForm.value))
    this.showResults = true;
    //this.result = this.fromValue * this.rate;
    this.http.get<number>('https://localhost:44374/api/Convert/Convert/' + this.fromUnit + "/" + this.toUnit + "/" + this.fromValue).subscribe(result => {
      this.result = result;      
    }, error => console.error(error));
  }

}
