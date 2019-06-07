import { Component, OnInit } from '@angular/core';
import { ModeratorService } from 'src/app/services/moderator.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NewsForPanel } from 'src/app/models/news-for-panel';

@Component({
  selector: 'app-news-panel',
  templateUrl: './news-panel.component.html',
  styleUrls: ['./news-panel.component.scss']
})
export class NewsPanelComponent implements OnInit {

  news: NewsForPanel[];
  newspart: number = 3;
  section: string ='all';

  constructor(private moderatorService: ModeratorService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.news = data['news'];
    });
  }

  getNextNewsPart() {
    this.newspart++;
    this.moderatorService.getNews(this.section, this.newspart.toString(), '10').subscribe(data => {
      data.forEach(item => {
        this.news.push(item);
      });
    });
  }

  getNewsForSelectedSection() {
    this.news = [];
    this.newspart = 3;
    this.moderatorService.getNews(this.section, '0', '30').subscribe(data => {
      data.forEach(item => {
        this.news.push(item);
      });
    });
  }

  deleteNews(id: number, index: number) {
    this.moderatorService.deleteNews(id).subscribe(() => {
    this.news.splice(index, 1);
    }, error => {
      console.log(error);
    });;
  }

  editNews(i: number) {
    this.router.navigate(['/edit/' + this.news[i].id]);
  }

}
