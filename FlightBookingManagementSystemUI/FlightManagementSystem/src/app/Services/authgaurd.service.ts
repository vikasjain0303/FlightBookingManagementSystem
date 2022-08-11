import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthgaurdService implements CanActivate {

  constructor(private _auth:UserService, private _router:Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(this._auth.isLoggedIn() && this._auth.adminLoggedIn())
    {
      return true;
    }
    else
    {
      window.alert('You are not authorised to view this page!! Redirecting you back to the Home page.')
      this._router.navigate(['Home']);
      return false;
    }
  }
}