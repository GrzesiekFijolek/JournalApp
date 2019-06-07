import { Comment } from "@angular/compiler";

export interface NewsForDetails {
  id: number,
  title: string,
  heading: string,
  content: string,
  photoUrl: string,
  section: string,
  author: string,
  addedAt: string,
  authorPhoto: string,
  comments: Comment[]
}