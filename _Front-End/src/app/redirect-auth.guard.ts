import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth.service';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class RedirectAuthGuard implements CanActivate {

  constructor
  (
  	private _authService: AuthService,
    private _router: Router,
    private _location: Location
  )
  {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean
  {
    if (this._authService.loggedIn())
    {
      this._router.navigate(['/perfil/'+localStorage.getItem('resID')]);
      return false;
    }
    else
    {
      return true;
    }
    
  }
}
