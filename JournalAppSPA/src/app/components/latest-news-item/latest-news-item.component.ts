import { Component, OnInit, Input, HostListener } from '@angular/core';
import { LatestNews } from 'src/app/models/latest-news';

@Component({
  selector: 'app-latest-news-item',
  templateUrl: './latest-news-item.component.html',
  styleUrls: ['./latest-news-item.component.scss']
})
export class LatestNewsItemComponent implements OnInit {

  @Input() news: LatestNews;
  // @HostListener('mouseenter') onHover() {
  //   console.log('asdf');
  // }

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
    switch(this.news.section) {
      case "poland": this.sectionPoland = true; break;
      case "business": this.sectionBusiness = true; break;
      case "policy": this.sectionPolicy = true; break;
      case "world": this.sectionWorld = true; break;
      case "sport": this.sectionSport = true; break;
      case "latest": this.sectionLatest = true; break;
    }

    this.actualSection = {
      "latest-news-item--poland": this.sectionPoland,
      "latest-news-item--business": this.sectionBusiness,
      "latest-news-item--policy": this.sectionPolicy,
      "latest-news-item--world": this.sectionWorld,
      "latest-news-item--sport": this.sectionSport,
      "latest-news-item--latest": this.sectionLatest,
    };
  }

  asdf() {
    console.log('asdf');
  }

}


