import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.scss']
})
export class BoxComponent implements OnInit {

  @Input() title: string;
  @Input() photo: string;
  @Input() id: number;
  @Input() section: string;

  sectionPoland: boolean = false;
  sectionBusiness: boolean = false;
  sectionPolicy: boolean = false;
  sectionWorld: boolean = false;
  sectionSport: boolean = false;
  sectionLatest: boolean = false;
  actualSection: any;
  boxShadow: any;
  boxHover: boolean = false;
 
  constructor() { }

  ngOnInit() {
  this.chooseColorTcheme();
  }

  chooseColorTcheme(){
    switch(this.section) {
      case "poland": this.sectionPoland = true; break;
      case "business": this.sectionBusiness = true; break;
      case "policy": this.sectionPolicy = true; break;
      case "world": this.sectionWorld = true; break;
      case "sport": this.sectionSport = true; break;
      case "latest": this.sectionLatest = true; break;
    }

    this.actualSection = {
      "box__title--poland": this.sectionPoland,
      "box__title--business": this.sectionBusiness,
      "box__title--policy": this.sectionPolicy,
      "box__title--world": this.sectionWorld,
      "box__title--sport": this.sectionSport,
      "box__title--latest": this.sectionLatest,
    };
  }

  addBoxShadow() {
  
      this.boxShadow = {
        "box__shadow--poland": this.sectionPoland && this.boxHover,
        "box__shadow--business": this.sectionBusiness && this.boxHover,
        "box__shadow--policy": this.sectionPolicy && this.boxHover,
        "box__shadow--world": this.sectionWorld && this.boxHover,
        "box__shadow--sport": this.sectionSport && this.boxHover,
        "box__shadow--latest": this.sectionLatest && this.boxHover,
      };
  }


}
