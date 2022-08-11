import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable,catchError,throwError } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private injector:Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let authService=this.injector.get(UserService);
    let tokenizedreq=req.clone({
      headers:req.headers.set('Authorization','bearer '+ authService.GetToken())
    })
    return next.handle(tokenizedreq).pipe(catchError(err => {
      if(err.status == 401 && !err.url.includes('login'))
      {
         window.alert('Session Timed out!!')
         authService.LogoutUser();
      }
      
      return throwError(err);
    }))
  }

}
