import { Component, OnInit, Input } from '@angular/core';
import { LatestNews } from 'src/app/models/latest-news';

@Component({
  selector: 'app-latest-news',
  templateUrl: './latest-news.component.html',
  styleUrls: ['./latest-news.component.scss']
})
export class LatestNewsComponent implements OnInit {

  @Input() news: LatestNews[];
  constructor() { }

  ngOnInit() {
  }

}
