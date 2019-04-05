import numpy as np
import cv2
import keyboard
import pyautogui

def keykey(center):
	x = int(center[0])
	y = int(center[1])
	if(x>200 and x<400 and y<200):
		keyboard.press_and_release('w')
	elif(x<200 and y>200 and y<400):
		keyboard.press_and_release('a')
	elif(x>200 and x<400 and y>200):
		keyboard.press_and_release('s')
	elif(x>400 and y>200 and y<400):
		keyboard.press_and_release('d')

	

cam = cv2.VideoCapture(0)
cam.set(cv2.CAP_PROP_FRAME_WIDTH,3840)
cam.set(cv2.CAP_PROP_FRAME_HEIGHT,2160)
while True:
    ret,img = cam.read()


    # red color boundaries (BGR) just rearrange rgb
    upper = [173, 164, 255]
    lower = [37, 21, 186]

    # create NumPy arrays from the boundaries
    lower = np.array(lower, dtype="uint8")
    upper = np.array(upper, dtype="uint8")

# find the colors within the specified boundaries and apply
# the mask
    mask = cv2.inRange(img, lower, upper)
    output = cv2.bitwise_and(img, img, mask=mask)

    ret,thresh = cv2.threshold(mask, 40, 255, 0)
    contours,hierarchy = cv2.findContours(thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)


    if len(contours) != 0:
        # draw in blue the contours that were founded
        cv2.drawContours(output, contours, -1, 255, 3)

        #find the biggest area
        c = max(contours, key = cv2.contourArea)

        x,y,w,h = cv2.boundingRect(c)
        center = (x,y)
        print(center)
        #pyautogui.moveTo(center)
        # draw the book contour (in green)
        cv2.rectangle(output,(x,y),(x+w,y+h),(0,255,0),2)

# show the imgs
    cv2.imshow("Result", np.hstack([output]))

    k = cv2.waitKey(33)
    if k==27:
        break
