import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-others-news-item',
  templateUrl: './others-news-item.component.html',
  styleUrls: ['./others-news-item.component.scss']
})
export class OthersNewsItemComponent implements OnInit {

  @Input() shortTitle: string;
  @Input() photoUrl: string;
  @Input() id: number;
  
  constructor() { }

  ngOnInit() {
  }

}
