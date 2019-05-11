import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: 'app-converter-component',
  templateUrl: './converter.component.html'
})

export class ConverterComponent {
  constructor(public fb: FormBuilder) { }

  convertForm = this.fb.group({
    fromUnit: [''],
    toUnit: ['']
  })

  public fromUnit: "";
  public toUnit: "";
  public fromUnits: any = ['Centimeter', 'Inch', 'Meter', 'Yard'];
  public toUnits: any = [];

  public changeFromUnit(http: HttpClient) {
    alert("Changed From Unit: " + JSON.stringify(this.convertForm.value));

    http.get<string[]>('api/Convert/ToUnits/' + this.convertForm.value.fromUnit).subscribe(result => {
      this.toUnits = result;
    }, error => console.error(error));

  }

  onSubmit() {
    alert("Submitted: " + JSON.stringify(this.convertForm.value))
  }

}
