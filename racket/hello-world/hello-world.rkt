#lang racket

(provide hello)
(define hello
  (lambda ([x "World"])
    (string-append "Hello, " x "!")))

