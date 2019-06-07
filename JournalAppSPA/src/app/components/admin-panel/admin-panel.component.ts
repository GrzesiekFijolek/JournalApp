import { Component, OnInit } from '@angular/core';
import { UserForAdminPanel } from 'src/app/models/user-for-admin-panel';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  users: UserForAdminPanel[];
  userspart: number = 3;

  constructor(private route: ActivatedRoute, private adminService: AdminService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data['users'];
    })
  }

  getNextUsersPart() {
    this.userspart++;
    this.adminService.getUsers(this.userspart.toString(), '10').subscribe(data => {
      data.forEach(item => {
        this.users.push(item);
      });
    });
  }

  updateUser($event, i: any) {
    console.log(i);
    console.log($event);
    this.users[i].userRoles = $event;
  }

  deleteUser(i: any) {
    this.adminService.deleteUser(this.users[i].username).subscribe(() => {
      this.users.splice(i, 1);
    }, error => {
      console.log(error);
    });;
  }
}
