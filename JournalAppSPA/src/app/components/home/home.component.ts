import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataForHome } from 'src/app/models/data-for-home';
import { NewsService } from 'src/app/services/news.service';
import { LatestNews } from 'src/app/models/latest-news';
import { NewsForHome } from 'src/app/models/news-for-home';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  data: DataForHome;
  sectionPolandNews: NewsForHome[];
  sectionBusinessNews: NewsForHome[];
  sectionWorldNews: NewsForHome[];
  sectionPolicyNews: NewsForHome[];
  sectionSportNews: NewsForHome[];
  importantNews: NewsForHome[];
  latestNews: LatestNews[];

  routeSectionWorld: string = "world";
  constructor(private route: ActivatedRoute, private n: NewsService) { }

  ngOnInit() {
    this.route.data.subscribe(d => {
        this.data = d['news'];
        this.sectionBusinessNews = this.data.sectionBusinessNews;
        this.sectionPolandNews = this.data.sectionPolandNews;
        this.sectionPolicyNews = this.data.sectionPolicyNews;
        this.sectionWorldNews = this.data.sectionWorldNews;
        this.sectionSportNews = this.data.sectionSportNews;
        this.importantNews = this.data.importantNews;
        this.latestNews = this.data.latestNews;
    });
  }

}
