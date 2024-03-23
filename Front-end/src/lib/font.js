import { Cormorant, DM_Sans } from 'next/font/google'

export const cormorant = Cormorant({
    weight: ['400', '500', '600', '700'],
    subsets: ['latin'],
    variable: "--cormorant",
    display: 'swap',
})
export const  dmSans= DM_Sans({
    weight: ['400', '500', '700'],
    subsets: ['latin'],
    variable: "--dmSans",
    display: 'swap',
})
