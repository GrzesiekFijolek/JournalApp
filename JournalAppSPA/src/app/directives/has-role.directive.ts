import { Directive, ViewContainerRef, TemplateRef, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { RoleService } from '../services/role.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  @Input() appHasRole: string[];
  isVisible = false;
  jwtHelper = new JwtHelperService();

  constructor(
    private viewContainerRef: ViewContainerRef,
    private templateRef: TemplateRef<any>,
    private authService: AuthService,
    private roleService: RoleService) { }

  ngOnInit() {
    this.checkRoles();

    this.roleService.userChanged.subscribe(() => {
      this.checkRoles();
    })
  }

  checkRoles() {
    var decodeToken = this.jwtHelper.decodeToken(localStorage.getItem('token'));
    if(!decodeToken) {
      this.viewContainerRef.clear();
    }
    else {
      var isMatch = false;
      var decodeToken = this.jwtHelper.decodeToken(localStorage.getItem('token'));
      var userRoles = decodeToken.role as Array<string>;
      this.appHasRole.forEach(role => {
      if(userRoles.includes(role)) {
        isMatch = true;
        return;
      }
    });
      if(isMatch) {
        if (!this.isVisible) {
          this.isVisible = true;
          this.viewContainerRef.createEmbeddedView(this.templateRef);
        } 
        else {
          this.isVisible = false;
          this.viewContainerRef.clear();
        }
      }
    }
  }

}
