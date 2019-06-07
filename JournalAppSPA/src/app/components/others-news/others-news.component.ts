import { Component, OnInit, Input } from '@angular/core';
import { LatestNews } from 'src/app/models/latest-news';

@Component({
  selector: 'app-others-news',
  templateUrl: './others-news.component.html',
  styleUrls: ['./others-news.component.scss']
})
export class OthersNewsComponent implements OnInit {

  @Input() otherNews: LatestNews[];

  section: string;
  sectionPoland: boolean = false;
  sectionBusiness: boolean = false;
  sectionPolicy: boolean = false;
  sectionWorld: boolean = false;
  sectionSport: boolean = false;
  sectionLatest: boolean = false;
  actualSection: any;
  header: string;

  constructor() { }

  ngOnInit() {
    this.section = this.otherNews[0].section;
    this.chooseColorTcheme();
    this.setHeader();
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
      "other__news--poland": this.sectionPoland,
      "other__news--business": this.sectionBusiness,
      "other__news--policy": this.sectionPolicy,
      "other__news--world": this.sectionWorld,
      "other__news--sport": this.sectionSport,
      "other__news--latest": this.sectionLatest,
    };
  }

  setHeader() {
    switch(this.section) {
      case('poland'):
      this.header = 'Polska'; break;
      case('policy'):
      this.header = 'Polityka'; break;
      case('world'):
      this.header = 'Świat'; break;
      case('business'):
      this.header = 'Biznes'; break;
      case('sport'):
      this.header = 'Sport'; break;
    }
  }

}
