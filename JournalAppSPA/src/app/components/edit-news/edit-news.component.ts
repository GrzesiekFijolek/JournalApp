import { Component, OnInit } from '@angular/core';
import { ModeratorService } from 'src/app/services/moderator.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { NewsForEdit } from 'src/app/models/news-for-edit';

@Component({
  selector: 'app-edit-news',
  templateUrl: './edit-news.component.html',
  styleUrls: ['./edit-news.component.scss']
})
export class EditNewsComponent implements OnInit {

  newsForm: FormGroup;
  imagePath: any;
  imgURL: any;
  serverError: any;
  news: NewsForEdit;
  file: any;
  fileChanged = false;

  constructor(private moderatorService: ModeratorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.news = data['news'];
      this.imgURL = this.news.photo;
    });
  }


  addNews() {
    var fd = new FormData();
    if(this.fileChanged) fd.append('File', this.file);
    // else fd.append('File', null);
    fd.append('Content', this.news.content);
    fd.append('Title', this.news.title);
    fd.append('ShortTitle', this.news.shortTitle);
    fd.append('Section', this.news.section);
    fd.append('Heading', this.news.heading);
    fd.append('IsImportant', this.news.isImportant ? 'true' : 'false');
    this.moderatorService.editNews(this.route.snapshot.params.id, fd).subscribe(() => {
      this.router.navigate([this.news.section]);
    }, error => {
      console.log(error);
    });
    
  }

  imgPreview($event) {
    var file = $event.target.files[0];
    if (file.length === 0)
      return;
  
    this.file = file;
    var reader = new FileReader();
    this.imagePath = this.file;
    reader.readAsDataURL(this.file); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result; 
    }
    this.fileChanged = true;
  }

}
