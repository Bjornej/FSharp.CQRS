module Events
open System;

type ConversationCreated = {
    SenderId:int
    Title: string
    Message:string
    TimeStamp:DateTime
}

type ConversationResponded = {
    SenderId:int
    Message:string
    TimeStamp:DateTime
}

type ConversationReplied = {
    SenderId:int
    Message:string
    TimeStamp:DateTime
}

type ConversationEvent = 
    | Created of ConversationCreated
    | Responded of ConversationResponded
    | Replied of ConversationReplied
