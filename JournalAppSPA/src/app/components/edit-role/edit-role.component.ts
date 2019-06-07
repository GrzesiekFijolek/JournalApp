import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserForAdminPanel } from 'src/app/models/user-for-admin-panel';
import { AdminService } from 'src/app/services/admin.service';
import { Roles } from 'src/app/models/roles';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.scss']
})
export class EditRoleComponent implements OnInit {

  @Input() roles: string[];
  @Input() username: string;
  @Output() changeUserRoles: EventEmitter<string[]> = new EventEmitter<string[]>();
  isAdmin: boolean;
  isModerator: boolean;

  constructor(private adminService: AdminService) { }

  ngOnInit() {
    this.checkAdmin() ? this.isAdmin = true : this.isAdmin = false;
    this.checkModerator() ? this.isModerator = true : this.isModerator = false;
  }

  edit() {
    var roles: Roles = new Roles();
    this.isAdmin ? roles.isAdmin = true : roles.isAdmin = false;
    this.isModerator ? roles.isModerator = true : roles.isModerator = false;
    

    this.adminService.editRoles(roles, this.username).subscribe((response: string[]) => {
      this.changeUserRoles.emit(response);

    }, error => {
      console.log(error);
    });

  }

  checkAdmin() {
    var x = false;
    this.roles.forEach(item => {
      if(item == "Admin") {
        x = true;
      }
    });

    return x;
  }

  checkModerator() {
    var x = false;
    this.roles.forEach(item => {
      if(item == "Moderator") {
        x = true;
      }
    });

    return x;
  }

}
