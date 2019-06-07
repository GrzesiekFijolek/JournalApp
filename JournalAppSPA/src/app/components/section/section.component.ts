import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewsService } from 'src/app/services/news.service';
import { NewsForSection } from 'src/app/models/news-for-section';
@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.scss']
})
export class SectionComponent implements OnInit {

  news: NewsForSection[];
  section: string;
  newsPart: number = 2;
  scrollToUp: boolean;
  header: string;

  sectionPoland: boolean = false;
  sectionBusiness: boolean = false;
  sectionPolicy: boolean = false;
  sectionWorld: boolean = false;
  sectionSport: boolean = false;
  sectionLatest: boolean = false;
  actualSection: any;

  constructor(private route: ActivatedRoute, private newsService: NewsService) {}
    
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.news = data['news'];
      this.section = data['section'];
      this.setHeader();
      this.chooseColorTcheme();
      });
      
      window.scroll(0,0);
  }

getNextNewsPart() {
    this.newsPart++;
    this.newsService.getSectionNews(this.section, this.newsPart.toString(), '8')
    .subscribe(data => {
      data.forEach(item => {
        this.news.push(item);
      });
    });    
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

chooseColorTcheme(){
  switch(this.section) {
    case "poland": this.sectionPoland = true; break;
    case "business": this.sectionBusiness = true; break;
    case "policy": this.sectionPolicy = true; break;
    case "world": this.sectionWorld = true; break;
    case "sport": this.sectionSport = true; break;
  }
  
  this.actualSection = {
    "section__header--poland": this.sectionPoland,
    "section__header--business": this.sectionBusiness,
    "section__header--policy": this.sectionPolicy,
    "section__header--world": this.sectionWorld,
    "section__header--sport": this.sectionSport
  };
}

}
