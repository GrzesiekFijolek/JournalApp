import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent implements OnInit {

  @Input() sectionRoute: string;
  @Input() sectionName: string;

  sectionPoland: boolean = false;
  sectionBusiness: boolean = false;
  sectionPolicy: boolean = false;
  sectionWorld: boolean = false;
  sectionSport: boolean = false;
  sectionClass: any;
  sectionTextClass: any;
  constructor() { }

  ngOnInit() {
    this.chooseColorTcheme();

    this.sectionClass = {
      "section-header--poland": this.sectionPoland,
      "section-header--business": this.sectionBusiness,
      "section-header--policy": this.sectionPolicy,
      "section-header--world": this.sectionWorld,
      "section-header--sport": this.sectionSport,
    };

    this.sectionTextClass = {
      
      "section-header__text--poland": this.sectionPoland,
      "section-header__text--business": this.sectionBusiness,
      "section-header__text--policy": this.sectionPolicy,
      "section-header__text--world": this.sectionWorld,
      "section-header__text--sport": this.sectionSport,
    };
  }

  chooseColorTcheme(){
    switch(this.sectionRoute) {
      case "poland": this.sectionPoland = true; break;
      case "business": this.sectionBusiness = true; break;
      case "policy": this.sectionPolicy = true; break;
      case "world": this.sectionWorld = true; break;
      case "sport": this.sectionSport = true; break;
    }

  }
}
