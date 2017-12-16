//
//  MasterViewController.swift
//  HW5
//
//  Created by Rehum Padua on 2/15/17.
//  Copyright © 2017 Rehum Padua. All rights reserved.
//

import UIKit
import Foundation

class MasterViewController: UITableViewController {

    var detailViewController: DetailViewController? = nil
    var objects = [Items]()
    let fmgr = FileManager.default
    
    func createItems() ->[Items]
    {
        let item1 = Items(name: "In The End", description: loadString(item:"1"), image: #imageLiteral(resourceName: "park"))
        let item2 = Items(name: "All Star", description: loadString(item:"2"), image: #imageLiteral(resourceName: "smash"))
        let item3 = Items(name: "I Want it That Way", description: loadString(item:"3"), image:#imageLiteral(resourceName: "back"))
        let item4 = Items(name: "Hit Me Baby", description: loadString(item:"4"), image: #imageLiteral(resourceName: "brit"))
        let item5 = Items(name: "Thousand Miles", description: loadString(item:"5"), image: #imageLiteral(resourceName: "thousand"))
        let item6 = Items(name: "Photograph", description: loadString(item:"6"), image: #imageLiteral(resourceName: "nickle"))
        let item7 = Items(name: "Friday", description: loadString(item:"7"), image: #imageLiteral(resourceName: "black"))
        let item8 = Items(name: "Baby", description: loadString(item:"8"), image: #imageLiteral(resourceName: "bieber"))
        let item9 = Items(name: "My Humps", description: loadString(item:"9"), image: #imageLiteral(resourceName: "peas"))
        let item10 = Items(name: "What does the Fox Say", description: loadString(item:"10"), image: #imageLiteral(resourceName: "ylvis"))
        let item11 = Items(name: "Hips Don't Lie", description: loadString(item:"11"), image: #imageLiteral(resourceName: "shaq"))
        let item12 = Items(name: "Call me Maybe", description: loadString(item:"12"), image: #imageLiteral(resourceName: "jepsen"))
        let item13 = Items(name: "Never Gonna Give You Up", description: loadString(item:"13"), image: #imageLiteral(resourceName: "astley"))
        let item14 = Items(name: "Hotline Bling", description: loadString(item:"14"), image: #imageLiteral(resourceName: "drake"))
        let item15 = Items(name: "Wake Me Up Inside", description: loadString(item:"15"), image: #imageLiteral(resourceName: "wakemeup"))
        let item16 = Items(name: "Lose Yourself", description: loadString(item:"16"), image: #imageLiteral(resourceName: "spaghetti"))
        let item17 = Items(name: "Milkshake", description: loadString(item:"17"), image: #imageLiteral(resourceName: "milk"))
        let item18 = Items(name: "Sk8r boi", description: loadString(item:"18"), image: #imageLiteral(resourceName: "avril"))
        let item19 = Items(name: "Slam Jam", description: loadString(item:"19"), image: #imageLiteral(resourceName: "bugs"))
        let item20 = Items(name: "Nyan Cat Song", description: loadString(item:"20"), image: #imageLiteral(resourceName: "nyan"))
        let item21 = Items(name: "Gangnam Style", description: loadString(item:"21"), image: #imageLiteral(resourceName: "psy"))
        let item22 = Items(name: "Why You Always Lying", description: loadString(item:"22"), image:#imageLiteral(resourceName: "fraser") )
        let item23 = Items(name: "Whip Nae Nae", description: loadString(item:"23"), image:#imageLiteral(resourceName: "nae") )
        let item24 = Items(name: "Wrecking Ball", description: loadString(item:"24"), image:#imageLiteral(resourceName: "ball") )
        let item25 = Items(name: "Crank Dat", description: loadString(item:"25"), image:#imageLiteral(resourceName: "soulja") )
        let item26 = Items(name: "Barbie Girl", description: loadString(item:"26"), image:#imageLiteral(resourceName: "babrie") )
        let item27 = Items(name: "All About That Bass", description: loadString(item:"27"), image:#imageLiteral(resourceName: "bass") )
        let item28 = Items(name: "Let it Go", description: loadString(item:"28"), image:#imageLiteral(resourceName: "elsa") )
        let item29 = Items(name: "22", description: loadString(item:"29"), image:#imageLiteral(resourceName: "swift") )
        let item30 = Items(name: "Thinking Out Loud", description: loadString(item:"30"), image:#imageLiteral(resourceName: "ed") )


        return[item1,item2,item3,item4,item5,item6,item7,item8,item9,item10,item11,item12,item13,item14,item15,item16,item17,item18,item19,item20,item21,item22,item23,item24,item25,item26,item27,item28,item29,item30]
    }
    func loadString(item:String)->String
    {
        
        let path = Bundle.main.path(forResource: item, ofType: "txt")
        
            do
            {
                let data = try String(contentsOfFile: path!, encoding: .ascii)
                
                return data
            }
            catch
            {
                print(error)
            }
        
        
        return "lol"
        
    }

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        self.navigationItem.leftBarButtonItem = self.editButtonItem
        self.title = "Good Music Player"
        objects = createItems()
        
    }

    override func viewWillAppear(_ animated: Bool) {
        self.clearsSelectionOnViewWillAppear = self.splitViewController!.isCollapsed
        super.viewWillAppear(animated)
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    
    // MARK: - Segues

    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "showDetail" {
            if let indexPath = self.tableView.indexPathForSelectedRow {
                let object1 = objects[indexPath.row] 
                let controller = (segue.destination as! UINavigationController).topViewController as! DetailViewController
                controller.detailItem = object1
                controller.navigationItem.leftBarButtonItem = self.splitViewController?.displayModeButtonItem
                controller.navigationItem.leftItemsSupplementBackButton = true
            }
        }
    }

    // MARK: - Table View

    override func numberOfSections(in tableView: UITableView) -> Int {
        return 1
    }

    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return objects.count
    }

    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "Cell", for: indexPath) as UITableViewCell

        let objectrow = objects[indexPath.row] as Items
        cell.textLabel!.text = objectrow.name
        cell.imageView!.image = objectrow.image
        return cell
    }

    override func tableView(_ tableView: UITableView, canEditRowAt indexPath: IndexPath) -> Bool {
        // Return false if you do not want the specified item to be editable.
        return true
    }

    override func tableView(_ tableView: UITableView, commit editingStyle: UITableViewCellEditingStyle, forRowAt indexPath: IndexPath) {
        if editingStyle == .delete {
            objects.remove(at: indexPath.row)
            tableView.deleteRows(at: [indexPath], with: .fade)
        } else if editingStyle == .insert {
            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
        }
    }


}

