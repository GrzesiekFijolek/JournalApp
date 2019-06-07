import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Comment } from '../../models/comment';
import { ModeratorService } from 'src/app/services/moderator.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  @Input() comment: Comment;
  @Input() index: number;
  @Output() commentDeleted: EventEmitter<number> = new EventEmitter<number>();

  constructor(private moderatorService: ModeratorService) { }

  ngOnInit() {
  }

  deleteComment() {

    return this.moderatorService.deleteComment(this.comment.id).subscribe(() => {
      this.commentDeleted.emit(this.index);
    }, error => {
      console.log(error);
    })
  }
}
