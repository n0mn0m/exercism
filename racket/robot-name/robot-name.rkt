#lang racket

(provide make-robot
         name
         reset!
         reset-name-cache!)

(define robot-set (mutable-set))

(define (make-robot)
  (let ([name (random-name)])
    (if (set-member? robot-set name) (make-robot) (begin (set-add! robot-set name) name))))

(define (name robot) robot)

(define (reset! robot) (set-remove! robot-set robot) (make-robot))

(define (reset-name-cache!) (set-clear! robot-set))

; functions to help generate a robot name
(define (random-char ascii-start ascii-end) (integer->char (random ascii-start ascii-end)))
; asciitable.com
(define (random-letter) (random-char 65 91))
(define (random-number) (random-char 48 58))
(define (random-name) (string (random-letter) (random-letter) (random-number) (random-number) (random-number)))
