//
//  View.swift
//  HW6
//
//  Created by Rehum Padua on 2/26/17.
//  Copyright © 2017 Rehum Padua. All rights reserved.
//

import Foundation
import UIKit

class Drawy: UIView
{
    
    var mouselocation: CGPoint = CGPoint(x:300,y:70)
    /*override init(frame: CGRect) {
        super.init(frame: frame)
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }*/
    override func draw(_ rect: CGRect) {
        // Drawing code
        let viewy : CGRect = UIScreen.main.bounds
        let path = UIBezierPath()
        let widthy = viewy.width
        let heighty = viewy.height
        UIColor.lightGray.setStroke()
        path.lineWidth = 2.0
        let bez = mouselocation
        path.move(to: CGPoint(x:0,y:0))
        path.addCurve(to: CGPoint(x:widthy,y:heighty), controlPoint1: bez, controlPoint2: bez)
        path.stroke()
        self.setNeedsDisplay()
        
    }
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        let touch = touches.first
        mouselocation = touch!.location(in: self)
        draw(UIScreen.main.bounds)
    }
    
    

}
/*class Mousey: UIViewController
{
    var mousey = CGPoint(x:500,y:700)
    let f = Drawy(frame:UIScreen.main.bounds)
    override func viewDidLoad() {
        super.viewDidLoad()
        view.addSubview(f)
    }
    func refres()
    {
        
        f.mouselocation = mousey
        f.setNeedsDisplay()
    }
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        let touch = touches.first
        mousey = touch!.location(in: self.view)
        refres()
    }
}*/
