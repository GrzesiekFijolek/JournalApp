import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NewsForCreate } from 'src/app/models/news-for-create';
import { ModeratorService } from 'src/app/services/moderator.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-add-news',
  templateUrl: './add-news.component.html',
  styleUrls: ['./add-news.component.scss']
})
export class AddNewsComponent implements OnInit {

  newsForm: FormGroup;
  imagePath: any;
  imgURL: any;
  serverError: any;
  news: NewsForCreate;
  jwtHelper = new JwtHelperService();

  constructor(private moderatorService: ModeratorService, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.news = new NewsForCreate();
    this.news.IsImportant = false;
  }

  
  addNews() {
    var token = this.jwtHelper.decodeToken(localStorage.getItem('token'))
    var fd = new FormData();
    fd.append('File', this.news.File);
    fd.append('Content', this.news.Content);
    fd.append('Title', this.news.Title);
    fd.append('ShortTitle', this.news.ShortTitle);
    fd.append('Section', this.news.Section);
    fd.append('Heading', this.news.Heading);
    fd.append('IsImportant', this.news.IsImportant ? 'true' : 'false');
    fd.append('AuthorId', token.nameid);
    this.moderatorService.addNews(fd).subscribe(() => {
      this.router.navigate([this.news.Section]);
    });

  }

  changeStatus() {
    this.news.IsImportant = !this.news.IsImportant;
  }

  imgPreview($event) {
    var file = $event.target.files[0];
    if (file.length === 0)
      return;

    this.news.File = file;
    var reader = new FileReader();
    this.imagePath = this.news.File;
    reader.readAsDataURL(this.news.File); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result; 
    }
  }


}
