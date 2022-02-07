import { Injectable } from '@angular/core';
import { CanActivate,CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, Router  } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  public user: User;
  public resID:string;

  constructor
  (
  	private _authService: AuthService,
    private _router: Router,
    private _userService: UserService,
  )
  {
    this.resID = localStorage.getItem('resID');
    this.getUser(this.resID);

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean
  {
    if (this._authService.loggedIn())
    {
      return true
    }
    else
    {
      this._router.navigate(['/login'])
      return false
    }
    
  }

  getUser(id)
  {
    this._userService.getUser(id).subscribe
    (
      response =>
      {
        this.user = response.user;
      },
      error =>
      {
        console.log(<any>error);
      }
    );
  }


 canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean
  {
    console.log(this.user);
    
    if(this.user)
    {
      if(this.user.tipo=="admin")
      {
        return true
      }
    }else
    {
      this._router.navigate(['restringido']);
      return false
    }
  }

}
