(defun gcd_of_list (mylst)
    (cond ((null mylst) nil)
          ((null (cdr mylst)) (car mylst))
          ((gcd (car mylst) (gcd_of_list (cdr mylst))))))

(print (gcd_of_list '(120 216 66 6)))