//
//  DetailViewController.swift
//  HW5
//
//  Created by Rehum Padua on 2/15/17.
//  Copyright Â© 2017 Rehum Padua. All rights reserved.
//

import UIKit
import AVFoundation

class DetailViewController: UIViewController {

    
    
    
    @IBOutlet weak var obimage: UIImageView!
    @IBOutlet weak var obname: UINavigationItem!
    @IBOutlet weak var obdes: UITextView!
    let synthesizer = AVSpeechSynthesizer()
    

    func configureView() {
        // Update the user interface for the detail item.
        if let detail:AnyObject = self.detailItem
        {
            let dict = detail as! [String: String]
            if let title=self.obname
            {
                title.title = dict["Name"]
            }
            
            if let lyrics=self.obdes
            {
                lyrics.text = dict["Lyrics"]
            }
            if let image = self.obimage
            {
                let imi = UIImage(named: dict["Image"]!)
                image.image = imi
            }
            
            
        }
        
        
        
            }
    func speak(say:String, voice:String) {
        
        let utterance = AVSpeechUtterance(string:say)
        utterance.voice = AVSpeechSynthesisVoice(language: voice)
        
        utterance.rate = 0.4
        synthesizer.speak(utterance)
        
        
    }
    @IBAction func Sing(_ sender: Any) {
        speak(say: obdes.text, voice:"en-GB")
    }
    @IBAction func stop(_ sender: Any) {
        synthesizer.stopSpeaking(at: AVSpeechBoundary(rawValue: 0)!)
    }
  
    
    

    

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        self.configureView()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    var detailItem: AnyObject? {
        didSet {
            // Update the view.
            self.configureView()
        }
  †§êõÚî­A