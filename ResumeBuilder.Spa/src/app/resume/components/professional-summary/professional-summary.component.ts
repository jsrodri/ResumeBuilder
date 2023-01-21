import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-professional-summary',
  templateUrl: './professional-summary.component.html',
  styleUrls: ['./professional-summary.component.css']
})
export class ProfessionalSummaryComponent implements OnInit {
  @Input() professionalSummary: string = "";

  constructor() { }

  ngOnInit(): void {
  }

}
