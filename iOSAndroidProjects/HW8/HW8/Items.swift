//
//  Items.swift
//  HW5
//
//  Created by Rehum Padua on 2/15/17.
//  Copyright © 2017 Rehum Padua. All rights reserved.
//

import Foundation
import UIKit
class Items
{
    var name: String?
    var description: String?
    var image: UIImage?
    
    init(name: String, description: String, image: UIImage)
    {
        self.name = name
        self.description = description
        self.image = image
    }
}
