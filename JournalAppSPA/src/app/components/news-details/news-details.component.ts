import { Component, OnInit } from '@angular/core';
import { NewsForDetails } from 'src/app/models/news-for-details';
import { LatestNews } from 'src/app/models/latest-news';
import { ActivatedRoute, Router } from '@angular/router';
import { ModeratorService } from 'src/app/services/moderator.service';
import { Location } from '@angular/common';
import { Comment } from 'src/app/models/comment';
import { CommentForCreate } from 'src/app/models/comment-for-create';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-news-details',
  templateUrl: './news-details.component.html',
  styleUrls: ['./news-details.component.scss']
})
export class NewsDetailsComponent implements OnInit {

  news: NewsForDetails;
  otherInfo: LatestNews[];
  content: string;
  jwtHelper = new JwtHelperService();

  constructor(private route: ActivatedRoute, private moderatorService: ModeratorService,
     private router: Router, private location: Location, private authService: AuthService) { 
    
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.news = data['data'].newsForDetails;
      this.otherInfo = data['data'].newsForOtherInfos;
    });

  }

  editNews() {
    this.router.navigate(['/edit/' + this.route.snapshot.params.id]);
  }

  deleteNews() {

    return this.moderatorService.deleteNews(this.route.snapshot.params.id).subscribe(() => {
      this.location.back();
    });
  }

  deleteComment($event) {

   this.news.comments.splice($event, 1);
  }

  addComment() {
    var token = this.jwtHelper.decodeToken(localStorage.getItem('token'));
    var id = token.nameid;
    var comment: CommentForCreate = {
      newsId: this.news.id,
      authorId: id,
      content: this.content
    }

    this.moderatorService.addComment(comment).subscribe((response: any) => {
      this.news.comments.push(response);
    }, error => {
      console.log(error);
    })
  }

  isLoggedIn() {
    return this.authService.isLoggegIn();
  }
}
