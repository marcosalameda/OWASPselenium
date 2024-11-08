using System;
using System.Collections.Generic;
using CSGenio.business;
using CSGenio.core.messaging;
using CSGenio.framework;
using CSGenio.persistence;

namespace CSGenio.messaging
{
    public static class MessageMetadataFactory
    {

        public static MessageMetadata GeneratedMetadata()
        {
            var res = new MessageMetadata();
            
            //publishers
            res.Publishers.Add(new PublisherMetadata
            {
                Name = "INVENTORY",
                Group = "GQT",
                Description = "Inventory",
                Version = 2,
                Ack = new GqtInventoryAckProcessor(),
                NoReexport = false,
                Tables = new  List<PublisherTable>
                {
                    new PublisherTable
                    {
                        Table = "asspa",
                        Areas = new List<string>
                        {
                            "asspa",
                        },
                        IsAnex = false,
                        Fields = new HashSet<string>
                        {
                            "codasspa",
                            "toshow",
                            "decimalplaces",
                            "date",
                            "datatype",
                            "text",
                            "codkinde",
                            "quantity",
                            "codasset",
                        }
                    },
                    new PublisherTable
                    {
                        Table = "kinde",
                        Areas = new List<string>
                        {
                            "kinde",
                        },
                        IsAnex = true,
                        Fields = new HashSet<string>
                        {
                            "codkinde",
                            "designat",
                        }
                    },
                    new PublisherTable
                    {
                        Table = "asset",
                        Areas = new List<string>
                        {
                            "asset",
                        },
                        IsAnex = false,
                        Filter = new InternalOperationFormula( new List<ByAreaArguments> {
                                new ByAreaArguments(new string[] {"name"},new int[] {0},"asset","codasset"),
                            },
                            1, 
                            delegate(object []args,User user,string module,PersistentSupport sp) {
                                return (object)(!(((string)args[0]) == ""));
                            }),
                        Fields = new HashSet<string>
                        {
                            "codasset",
                            "codkinde",
                            "photo",
                            "name",
                            "assetnum",
                        }
                    },
                }
            });

            //subscribers
            res.Subscribers.Add(new SubscriberMetadata
            {
                Name = "INVENTORY",
                Group = "GQT",
                Description = "Test subscription to the inventory process",
                Version = 2,
                UseAck = true,
                Processor = new GqtInventoryMessageProcessor(),
                Tables = new List<SubscriberTable>
                {
                    new SubscriberTable {
                        Name = "kinde",
                        Alias = "kinde",
                    },
                    new SubscriberTable {
                        Name = "asset",
                        Alias = "asset",
                    },
                    new SubscriberTable {
                        Name = "asspa",
                        Alias = "asspa",
                    },
                },
            });
            return res;
        }

    }


}
