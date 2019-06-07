import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  userChanged: EventEmitter<void> = new EventEmitter<void>();
  constructor() { }

  emitChange() {
    this.userChanged.emit();
  }
}
