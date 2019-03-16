import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private route: ActivatedRoute,
              private messageService: MessageService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.getSingleMessageByUserId(+params.id);
    });

  }

  getSingleMessageByUserId(id: number) {
    this.messageService.getSingleMessageById(id)
    .subscribe((data) => {
      this.message = data;
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
