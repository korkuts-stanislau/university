;2^x
(defun exp2(x)
(cond
   ((zerop x) 1)
   (t (* 2(exp2(- x 1))))
)) 