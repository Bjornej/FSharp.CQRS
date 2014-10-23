module Conversation
open System

type Request = {
    Message:string
    TimeStamp : DateTime
}

type Response = {
    Message:string
    TimeStamp : DateTime
    ResponderId:int
}

type Reply = {
    Text:string
    TimeStamp: DateTime
}

type Message = 
    | Request
    | Response
    | Reply

type EstimatedResponseTime = 
    | None
    | Estimate of DateTime

type Conversation = {
    Id:int
    Version: int
    OwnerId:int
    Title:string
    Sender : int
    Messages: List<Message>
    Deadline: EstimatedResponseTime
}
 