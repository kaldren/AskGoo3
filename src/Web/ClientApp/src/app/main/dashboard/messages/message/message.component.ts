import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MessageService } from 'src/app/_services/message/message.service';
import { Message } from 'src/app/_models/message';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.less']
})
export class MessageComponent implements OnInit, OnDestroy {

  id: number;
  content: string;
  message: any;
  private sub: any;

  replyBtnClicked: boolean;

  constructor(private route: ActivatedRoute,
              private messageService: MessageService,
              private _location: Location) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.getSingleMessageByUserId(+params.id);
    });

    this.replyBtnClicked = false;
  }

  getSingleMessageByUserId(id: number) {
    this.messageService.getSingleMessageById(id)
    .subscribe((data) => {
      this.message = data;
    });
  }

  toggleReply() {
    this.replyBtnClicked = !this.replyBtnClicked;
    return this.replyBtnClicked;
  }

  backClicked() {
    this._location.back();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
